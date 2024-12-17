using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;

public class ItemGateWay
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }

    static string ItemTableName = "Item";

    public static List<ItemGateWay> SelectAll()
    {
        // DB 연결
        SqliteConnection connection = new SqliteConnection(ConnectionString.GetGameDBConnectionString());
        connection.Open();

        // DB 연결 실패 시 null 반환
        if (connection.State != ConnectionState.Open)
        {
            Debug.LogError($"Failed to connect Sql Lite Server, Connection String : {ConnectionString.GetGameDBConnectionString()}");
            return null;
        }

        List<ItemGateWay> result = new List<ItemGateWay>();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT id, name, atk, def FROM Item";
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            int index = 0;
            
            int id = reader.GetInt32(index++);
            string name = reader.GetString(index++);
            int atk = reader.GetInt32(index++);
            int def = reader.GetInt32(index++);

            ItemGateWay item = new ItemGateWay();
            item.Id = id;
            item.Name = name;
            item.Atk = atk;
            item.Def = def;
            result.Add(item);
        }

        reader.Close();

        return result;
    }

    public static ItemGateWay Select(int selectId)
    {
        // DB 연결
        SqliteConnection connection = new SqliteConnection(ConnectionString.GetGameDBConnectionString());
        connection.Open();

        // DB 연결 실패 시 null 반환
        if (connection.State != ConnectionState.Open)
        {
            Debug.LogError($"Failed to connect Sql Lite Server, Connection String : {ConnectionString.GetGameDBConnectionString()}");
            return null;
        }

        ItemGateWay result = new ItemGateWay();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT id, name, atk, def FROM Item WHERE id=@id";
        command.Parameters.Add(new SqliteParameter("@id", selectId));

        SqliteDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            int index = 0;

            int id = reader.GetInt32(index++);
            string name = reader.GetString(index++);
            int atk = reader.GetInt32(index++);
            int def = reader.GetInt32(index++);

            result.Id = id;
            result.Name = name;
            result.Atk = atk;
            result.Def = def;
        }

        reader.Close();

        return result;
    }

}
