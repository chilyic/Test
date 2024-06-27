using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Savings : MonoBehaviour
{
    [SerializeField] private Movement _player;
    [SerializeField] private Saveing _save;

    private string _path;

    void Start()
    {
        _path = Path.Combine(Application.dataPath, "Save.json");

        if (File.Exists(_path))
            Load();
    }

    private void Load()
    {
        _save = JsonUtility.FromJson<Saveing>(File.ReadAllText(_path));

        _player.transform.position = new(_save.posX, _save.posY, _save.posZ);
        //_player.Bonus = _save.notes;
        //_player.UpdateUI();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        _save.posX = _player.transform.position.x;
        _save.posY = _player.transform.position.y;
        _save.posZ = _player.transform.position.z;
        //_save.notes = _player.Bonus;

        File.WriteAllText(_path, JsonUtility.ToJson(_save, prettyPrint: true));
    }
}

[Serializable]
public struct Saveing
{
    public float posX;
    public float posY;
    public float posZ;
    public int notes;
}