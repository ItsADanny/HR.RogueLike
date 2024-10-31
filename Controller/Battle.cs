static class Battle
{
    public static void DoBattle(Monster? monster)
    {
        while (Game.ThePlayer.CurrHitPoints > 0 && monster?.CurrHitPoints > 0)
        {
            var (Faster, Slower) = Game.DetermineTurnOrder(Game.ThePlayer, monster);
            Fighter faster = Faster;
            Fighter slower = Slower;

            IDamage attack = new Attack(faster, slower);
            slower.TakeDamage(attack);
            if (slower.CurrHitPoints > 0)
            {
                attack = new Attack(slower, faster);
                faster.TakeDamage(attack);
            }
        }

        if (Game.ThePlayer?.CurrHitPoints <= 0)
        {
            Messages.PlayerIsDead(Game.ThePlayer.Name);
            Game.Stop();
        }
        Game.Victories++;
        Messages.PlayerWonFight(Game.ThePlayer.Name, monster.Name, Game.Victories);
        WonBattle();
    }

    public static int DealDamage(Fighter fighter)
    {
        if (fighter is not Player player)
        {
            return Game.Rand.Next(fighter.Strength / 2, fighter.Strength + 1);
        }

        int damage = Game.Rand.Next(player.Strength / 2, player.Strength + 1);

        if (HasDoubleDamage_And_LowHP(player))
            damage *= 2;

        bool isCrit = CheckIfCriticalHit(player);
        if (isCrit)
        {
            Messages.CriticalHit();
            if (Game.ThePlayer.RestoreHPOnCrit)
            {
                Game.ThePlayer.CurrHitPoints += RewardHPOnCrit.HealAmount;
            }
            damage = (int)(damage + (1 + player.CritDamage / 100.0));
        }
        
        return damage;
    }

    private static bool CheckIfCriticalHit(Player player)
    {
        if (player.GuaranteedCriticalHits >= 1)
        {
            player.GuaranteedCriticalHits--;
            return true;
        }

        return (player.CritChance >= Game.Rand.Next(100));
    }

    public static void TakeDamage(Fighter attacked, IDamage damage)
    {
        int amount = damage.DamageAmount;

        if (attacked is not Player player)
        {
            attacked.CurrHitPoints -= amount;
            Messages.TookDamage(attacked.Name, amount);
            return;
        }

        if (AttemptEvade(player))
        {
            Messages.HasEvadedAttack(player.Name);
            return;
        }

        if (!damage.IgnoreArmor && player.CurrArmor > 0)
        {
            if (amount <= player.CurrArmor)
            {
                player.CurrArmor -= amount;
                amount = 0;
            }
            else
            {
                amount -= player.CurrArmor;
                player.CurrArmor = 0;
            }
        }

        int damageReduction = player.Strength / 10;
        if (Game.ThePlayer.DexReducesDamage)
            damageReduction += player.Dexterity / 10;
        int reducedAmount = Math.Max(0, amount - damageReduction);

        player.CurrHitPoints -= reducedAmount;
        Messages.TookDamage(player.Name, reducedAmount);
    }

    private static bool AttemptEvade(Fighter defender)
    {
        if (defender is not Player player)
            return false;

        if (player.ExtraCritChanceNoEvade) // If this power is obtained, the player cannot evade.
            return false;

        double dodgeChance = player.Dexterity / (player.Dexterity + 250.0);
        bool success = Game.Rand.NextDouble() < dodgeChance;
        return success;
    }

    private static bool HasDoubleDamage_And_LowHP(Player player)
    {
        if (!player.LowHPDoubleDamage)
            return false;

        double hpRatio = (double)player.CurrHitPoints / player.MaxHitPoints;
        double hpRatioThreshold = RewardLowHPDoubleDamage.HPThresholdPercentage / 100.0;
        return hpRatio < hpRatioThreshold;
    }

    public static void WonBattle()
    {
        Menu.OfferRewards();
    }
}
