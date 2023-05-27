using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace MyPasswordManager.Classes
{
    using QueryParams = List<Tuple<string, dynamic>>;
    
    public class ParamFactory
    {
        public ParamFactory() {}
        public Tuple<string, dynamic> MakeParam(string key, dynamic value)
        {
            return new Tuple<string, dynamic>(key, value);
        }
    }

    public class SQLiteInterface
    {
        string ConnStr;
        string TblPath;
        string QueryPath;
        Dictionary<string, string> PresetQueries;

        public SQLiteInterface()
        {
        }

        public SQLiteInterface(string connStr, string tblPath, string queryPath)
        {
            ConnStr = connStr;
            TblPath = tblPath;
            QueryPath = queryPath;
            if (!File.Exists("PwdDB.sqlite"))
                SQLiteConnection.CreateFile("PwdDB.sqlite");

            PresetQueries = new Dictionary<string, string>();
            List<Tuple<string, string>> tblFiles = GetResourcesInDirectory(tblPath, ".sql");
            List<Tuple<string, string>> queryFiles = GetResourcesInDirectory(queryPath, ".sql");
            foreach(Tuple<string, string> tblFile in tblFiles)
            {
                string sql = ReadResource(tblFile.Item2);
                ExecuteNonQuery(sql, CommandType.Text);
            }
            foreach (Tuple<string, string> queryFile in queryFiles)
            {
                string sql = ReadResource(queryFile.Item2);
                PresetQueries.Add(queryFile.Item1, sql);
            }
        }

        public string ReadResource(string path)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
            {
                TextReader textReader = new StreamReader(stream);
                return textReader.ReadToEnd();
            }
        }

        public string GetPresetQuery(string name)
        {
            return PresetQueries[name];
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType, QueryParams parameters = null)
        {
            var conn = GetConnection();
            conn.Open();
            using (var cmd = CreateSQLCommand(conn, cmdText, cmdType, parameters))
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected;
            }
        }
        
        public List<NameValueCollection> ExecuteQuery(string cmdText, CommandType cmdType, QueryParams parameters = null)
        {
            var conn = GetConnection();
            conn.Open();
            using (var cmd = CreateSQLCommand(conn, cmdText, cmdType, parameters))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    List<NameValueCollection> results = new List<NameValueCollection>();

                    while(reader.Read())
                    {
                        results.Add(reader.GetValues());
                    }
                    conn.Close();
                    return results;
                    
                }
            }
        }

        private SQLiteConnection GetConnection()
        {
            return Singleton<SQLiteConnection>.GetInstance(ConnStr);
        }

        private SQLiteCommand CreateSQLCommand(SQLiteConnection conn, string cmdText, CommandType cmdType, QueryParams parameters)
        {
            SQLiteCommand cmd = new SQLiteCommand(cmdText, conn);
            cmd.CommandType = cmdType;
            if (parameters == null)
                return cmd;

            foreach (Tuple<string, dynamic> tuple in parameters)
            {
                cmd.Parameters.Add(new SQLiteParameter($"@{tuple.Item1}", tuple.Item2));
            }

            return cmd;
        }

        private List<Tuple<string,string>> GetResourcesInDirectory(string path, string ext)
        {
            List<Tuple<string,string>> resources = new List<Tuple<string, string>>();
            foreach (string resPath in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (resPath.Contains(path))
                {
                    string res = Regex.Replace(resPath, $".*{path.Replace(".", "\\.")}", "");
                    resources.Add(new Tuple<string, string>(res.Replace(ext, ""), resPath));
                }
            }
            return resources;
        }
    }
}
