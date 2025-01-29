using System;
using System.Collections.Generic;
using System.Linq;

public class RewardsManager
{
    private static Random random = new();

    public void SetRewards(ref List<int> rewards, RewardsManagerData rewardsManagerData)
    {
        while (rewards.Count < rewardsManagerData.segmentAmount)
        {
            int newReward = random.Next(rewardsManagerData.minRewardValue / rewardsManagerData.numberMultiplicity, rewardsManagerData.maxRewardValue / rewardsManagerData.numberMultiplicity + 1) * rewardsManagerData.numberMultiplicity;

            if (!rewards.Contains(newReward) &&
                (rewards.Count == 0 || rewards.All(existingReward => Math.Abs(existingReward - newReward) >= rewardsManagerData.minInterval)))
            {
                rewards.Add(newReward);
            }
        }
    }
}