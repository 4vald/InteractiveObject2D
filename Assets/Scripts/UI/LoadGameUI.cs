using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Save.Managers;

public class LoadGameUI : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private SaveManager saveManager;

    [Header("Slot 1")]
    [SerializeField] private TMP_Text slot1Name;
    [SerializeField] private TMP_Text slot1Created;
    [SerializeField] private TMP_Text slot1LastPlayed;
    [SerializeField] private GameObject slot1DeleteButton;

    [Header("Slot 2")]
    [SerializeField] private TMP_Text slot2Name;
    [SerializeField] private TMP_Text slot2Created;
    [SerializeField] private TMP_Text slot2LastPlayed;
    [SerializeField] private GameObject slot2DeleteButton;

    [Header("Slot 3")]
    [SerializeField] private TMP_Text slot3Name;
    [SerializeField] private TMP_Text slot3Created;
    [SerializeField] private TMP_Text slot3LastPlayed;
    [SerializeField] private GameObject slot3DeleteButton;

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        UpdateSlot(1, slot1Name, slot1Created, slot1LastPlayed, slot1DeleteButton);
        UpdateSlot(2, slot2Name, slot2Created, slot2LastPlayed, slot2DeleteButton);
        UpdateSlot(3, slot3Name, slot3Created, slot3LastPlayed, slot3DeleteButton);
    }

    private void UpdateSlot(
        int slot,
        TMP_Text name,
        TMP_Text created,
        TMP_Text lastPlayed,
        GameObject deleteButton)
    {
        SaveData save = saveManager.LoadSave(slot);

        if (save == null)
        {
            name.text = "Пусто";
            created.text = "";
            lastPlayed.text = "";

            deleteButton.SetActive(false);
            return;
        }

        name.text = save.SaveName;
        created.text = "Создан:\n" + save.CreatedAt;
        lastPlayed.text = "Последняя игра:\n" + save.LastPlayedAt;

        deleteButton.SetActive(true);
    }

    public void LoadSlot1()
    {
        LoadSlot(1);
    }

    public void LoadSlot2()
    {
        LoadSlot(2);
    }

    public void LoadSlot3()
    {
        LoadSlot(3);
    }

    private void LoadSlot(int slot)
    {
        if (!saveManager.HasSave(slot))
        {
            Debug.Log("Этот слот пуст.");
            return;
        }

        saveManager.SetCurrentSlot(slot);
        saveManager.UpdateLastPlayed(slot);

        SceneManager.LoadScene("MainScene");
    }

    public void DeleteSlot1()
    {
        DeleteSlot(1);
    }

    public void DeleteSlot2()
    {
        DeleteSlot(2);
    }

    public void DeleteSlot3()
    {
        DeleteSlot(3);
    }

    private void DeleteSlot(int slot)
    {
        saveManager.DeleteSave(slot);

        Refresh();
    }
}