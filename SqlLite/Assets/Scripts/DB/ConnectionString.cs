using UnityEngine;

public static class ConnectionString
{
    static private string GetDBConnectionString(string dbName)
    {
        return $"URI=file:{Application.streamingAssetsPath}{dbName}";
    }

    static public string GetGameDBConnectionString()
    {
        string dbName = "/GameDB.db";
        return GetDBConnectionString(dbName);
    }
}
