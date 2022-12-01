using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat.Storage;
using UnityEngine;
using UnityEngine.Events;
using Utils;

public class DBController : Singleton<DBController>
{
    [SerializeField] private DeviceLockLevel lockLevel = DeviceLockLevel.Soft;
    [SerializeField] private DeviceLockTamperingSensitivity sensitivity;

    #region VARIABLE


    private ObscuredInt _amountCollide;

    public ObscuredInt AMOUNTCOLLIDE
    {
        get => _amountCollide;
        set
        {
            _amountCollide = value;
            Save(DBKey.AMOUNTCOLLIDE, value.GetDecrypted());
        }

    }




    private ObscuredInt _level;

    public ObscuredInt LEVEL
    {
        get => _level;
        set
        {
            _level = value;
            Save(DBKey.LEVEL, value.GetDecrypted());
        }

    }    
       

    private ObscuredInt coin;

    public ObscuredInt COIN
    {
        get => coin;
        set
        {
            coin = value;
            Save(DBKey.COIN, value.GetDecrypted());
        }
    }

    #endregion

    protected override void CustomAwake()
    {
        ObscuredPrefs.DeviceLockSettings.Level = lockLevel;
        ObscuredPrefs.DeviceLockSettings.Sensitivity = sensitivity;
        Initializing();
    }

    void Initializing()
    {
        CheckDependency(DBKey.COIN, key => COIN = 0);
        CheckDependency(DBKey.LEVEL, key => LEVEL = 1);
        CheckDependency(DBKey.AMOUNTCOLLIDE, key => AMOUNTCOLLIDE = 0);
        Load();
    }


    void CheckDependency(string key, UnityAction<string> onComplete)
    {
        if (!ObscuredPrefs.HasKey(key))
        {
            onComplete?.Invoke(key);
        }
    }

    public void Save<T>(string key, T values)
    {
        
        if (typeof(T) == typeof(int) ||
            typeof(T) == typeof(bool) ||
            typeof(T) == typeof(string) ||
            typeof(T) == typeof(float) ||
            typeof(T) == typeof(long) ||
            typeof(T) == typeof(Quaternion) ||
            typeof(T) == typeof(Vector2) ||
            typeof(T) == typeof(Vector3) ||
            typeof(T) == typeof(Vector2Int) ||
            typeof(T) == typeof(Vector3Int))
        {
            ObscuredPrefs.Set(key, values);
        }
        else
        {
            try
            {
                ObscuredString json = JsonUtility.ToJson(values);
                ObscuredPrefs.Set(key, json);
            }
            catch (UnityException e)
            {
                throw new UnityException(e.Message);
            }
        }
    }

    public T LoadDataByKey<T>(string key)
    {
        if (typeof(T) == typeof(int) ||
            typeof(T) == typeof(bool) ||
            typeof(T) == typeof(string) ||
            typeof(T) == typeof(float) ||
            typeof(T) == typeof(long) ||
            typeof(T) == typeof(Quaternion) ||
            typeof(T) == typeof(Vector2) ||
            typeof(T) == typeof(Vector3) ||
            typeof(T) == typeof(Vector2Int) ||
            typeof(T) == typeof(Vector3Int))
        {
            var value = ObscuredPrefs.Get<T>(key);
            return value;
        }
        else
        {
            string json = ObscuredPrefs.Get<string>(key);
            return JsonUtility.FromJson<T>(json);
        }
    }

    public void Delete(string key)
    {
        ObscuredPrefs.DeleteKey(key);
    }

    public void DeleteAll()
    {
        ObscuredPrefs.DeleteAll();
    }

    void Load()
    {
        coin = LoadDataByKey<int>(DBKey.COIN);
        _level = LoadDataByKey<int>(DBKey.LEVEL);
        _amountCollide = LoadDataByKey<int>(DBKey.AMOUNTCOLLIDE);
        //print(coin);
    }
}

public class DBKey
{
    public readonly static string COIN = "COIN";
    public readonly static string LEVEL = "LEVEL";
    public readonly static string AMOUNTCOLLIDE = "AMOUNTCOLLIDE";
}

[Serializable]
public class Test
{
    public ObscuredInt ba;
}
