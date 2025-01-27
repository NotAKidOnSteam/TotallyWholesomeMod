﻿using TotallyWholesome.Managers.Achievements.Conditions;
using TWNetCommon.Data.ControlPackets;

namespace TotallyWholesome.Managers.Achievements.Achievements
{
    [ButtplugDeviceCondition(1)]
    [PiShockOperationPetCondition(ShockOperation.Shock, 100, 1)]
    [VibrationDurationCondition(0, 100)]
    public class InfinitePower : IAchievement
    {
        public string AchievementName => "Infinite Power!";
        public string AchievementDescription => "Get shocked and vibrated at max intensity!";
        public AchievementRank AchievementRank => AchievementRank.Silver;
        public AchievementCheckMode AchievementCheckMode => AchievementCheckMode.PerSecond;
        public AchievementConditionMode AchievementConditionMode => AchievementConditionMode.All;
        public ICondition[] AchievementConditions { get; set; }
        public bool AchievementAwarded { get; set; }
    }
}