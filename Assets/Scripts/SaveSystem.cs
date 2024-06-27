using UnityEngine;
using System;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Save _save;
    [SerializeField] private Movement _player;

    private string _path;

    void Start()
    {
        _path = Path.Combine(Application.dataPath, "Save.json");
        if (File.Exists(_path))
            Load();
    }

    private void Load()
    {
        _save = JsonUtility.FromJson<Save>(File.ReadAllText(_path));
        _player.transform.position = new Vector3(_save.posX, _save.posY, _save.posZ);
        //_player.Bonus = _save.objects;
        //_player.UpdateUI();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        _save.posX = _player.transform.position.x;
        _save.posY = _player.transform.position.y;
        _save.posZ = _player.transform.position.z;
        //_save.objects = _player.Bonus;

        if (File.Exists(_path))
            File.Delete(_path);

        File.WriteAllText(_path, JsonUtility.ToJson(_save, prettyPrint: true));
    }
}

[Serializable]
public struct Save
{
    public float posX;
    public float posY;
    public float posZ;
    public int objects;
}
