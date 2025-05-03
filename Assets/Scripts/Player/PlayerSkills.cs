using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    public void UnlockSkill(SkillType skillType)
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
}
