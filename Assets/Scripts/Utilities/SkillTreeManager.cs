using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour
{
    // Complete an objective to gain a new skill on the skill wheel
    // Face the final boss when all skills are gained

    // Press skill button to unlock a skill that is ted to a key press

    private PlayerSkills playerSkills;

    [Header("Skill Buttons")]
    [SerializeField]
    private Button earthBtn;

    [SerializeField]
    private Button electroBtn;

    [SerializeField]
    private Button speedBtn;

    [SerializeField]
    private Button throwBtn;

    private void Awake()
    {
        earthBtn.onClick.AddListener(UnlockSkillEarth);
        electroBtn.onClick.AddListener(UnlockSkillElectro);
        speedBtn.onClick.AddListener(UnlockSkillSpeed);
        throwBtn.onClick.AddListener(UnlockSkillThrow);
    }

    private void UnlockSkillSpeed()
    {
        playerSkills.UnlockSkill(PlayerSkills.SkillType.SpeedBoost);
    }

    private void UnlockSkillElectro()
    {
        playerSkills.UnlockSkill(PlayerSkills.SkillType.Electrocute);
    }

    private void UnlockSkillEarth()
    {
        playerSkills.UnlockSkill(PlayerSkills.SkillType.Earthshatter);
    }

    private void UnlockSkillThrow()
    {
        playerSkills.UnlockSkill(PlayerSkills.SkillType.ThrowOverarm);
    }

    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        this.playerSkills = playerSkills;
    }
}
