using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HANDLE ALL PLAYER SKILLS
public class PlayerSkills
{
    public event EventHandler<OnSkillUnlockedEventArgs> OnSkillUnlocked;

    public class OnSkillUnlockedEventArgs : EventArgs
    {
        public SkillType skillType;
    }

    public enum SkillType
    {
        None,
        Earthshatter,
        Electrocute,
        SpeedBoost,
        ThrowOverarm
    }

    private List<SkillType> unlockedSkillTypeList;

    public PlayerSkills()
    {
        unlockedSkillTypeList = new List<SkillType>();
    }

    private void UnlockSkill(SkillType skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            unlockedSkillTypeList.Add(skillType);
            OnSkillUnlocked.Invoke(this, new OnSkillUnlockedEventArgs { skillType = skillType });
        }
    }

    // Test if skill type has been unlocked
    public bool IsSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillTypeList.Contains(skillType);
    }

    public bool GetSkillRequirement(SkillType skillType)
    {
        return skillType switch
        {
            // SkillType.Earthshatter => CheckValue("Kill 10 Zombies"),
            // SkillType.Electrocute => CheckValue("Kill 20 Zombies"),
            // SkillType.SpeedBoost => CheckValue("Kill 30 Zombies"),
            // SkillType.ThrowOverarm => CheckValue("Kill 40 Zombies"),
            SkillType.None
                => false,
            _ => false,
        };
    }

    public void Test()
    {
        Debug.Log("cat");
    }

    public bool TryUnlockSkill(SkillType skillType)
    {
        bool objectiveRequirement = GetSkillRequirement(skillType);

        if (objectiveRequirement != false)
        {
            UnlockSkill(skillType);
            return true;
        }
        Debug.Log("not unlocked: " + skillType);
        return false;
    }

    public bool CanUnlockSkill(SkillType skillType)
    {
        bool objectiveRequirement = GetSkillRequirement(skillType);

        if (objectiveRequirement != false)
        {
            return true;
        }
        return false;
    }
}
