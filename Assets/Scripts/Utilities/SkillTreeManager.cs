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

    private Color unlockedColor;

    [SerializeField]
    private Color lockedColor;

    [SerializeField]
    private ObjectiveManager objectiveManager;

    private void Awake()
    {
        earthBtn.onClick.AddListener(UnlockSkillEarth);
        electroBtn.onClick.AddListener(UnlockSkillElectro);
        speedBtn.onClick.AddListener(UnlockSkillSpeed);
        throwBtn.onClick.AddListener(UnlockSkillThrow);

        unlockedColor = Color.white;
    }

    private void UnlockSkillSpeed()
    {
        if (objectiveManager.skillObjectives["Kill 10 Zombies"] == true)
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.SpeedBoost);
        }
    }

    private void UnlockSkillElectro()
    {
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Electrocute);
    }

    private void UnlockSkillEarth()
    {
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Earthshatter);
    }

    private void UnlockSkillThrow()
    {
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.ThrowOverarm);
    }

    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        this.playerSkills = playerSkills;
        playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
    }

    private void PlayerSkills_OnSkillUnlocked(
        object sender,
        PlayerSkills.OnSkillUnlockedEventArgs e
    )
    {
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (playerSkills.CanUnlockSkill(PlayerSkills.SkillType.Earthshatter))
        {
            Debug.Log("unlocked earth");
            earthBtn.GetComponent<Image>().color = unlockedColor;
        }
        else
        {
            Debug.Log("locked earth");
            earthBtn.GetComponent<Image>().color = lockedColor;
        }

        if (playerSkills.CanUnlockSkill(PlayerSkills.SkillType.Electrocute))
        {
            Debug.Log("unlocked");
            electroBtn.GetComponent<Image>().color = unlockedColor;
        }
        else
        {
            Debug.Log("locked electro");
            electroBtn.GetComponent<Image>().color = lockedColor;
        }

        if (playerSkills.CanUnlockSkill(PlayerSkills.SkillType.SpeedBoost))
        {
            Debug.Log("unlocked");
            speedBtn.GetComponent<Image>().color = unlockedColor;
        }
        else
        {
            Debug.Log("locked speed");
            speedBtn.GetComponent<Image>().color = lockedColor;
        }

        if (playerSkills.CanUnlockSkill(PlayerSkills.SkillType.ThrowOverarm))
        {
            Debug.Log("unlocked");
            throwBtn.GetComponent<Image>().color = unlockedColor;
        }
        else
        {
            Debug.Log("locked throw");
            throwBtn.GetComponent<Image>().color = lockedColor;
        }
    }
}
