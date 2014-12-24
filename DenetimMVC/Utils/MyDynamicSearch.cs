using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyUtils
{
    public  class MyDynamicSearch
    {
        public  static string FullColumnSearchSql(Type _entity, string aramaText, int tamEşleşmeMi=0,int dönecekKayıtSayısı=1000000)
        {
            string sortParam = " order by IslemTarihi desc";
            string aranan = aramaText;
            string sql = "select top " + dönecekKayıtSayısı + " * from " + _entity.Name;

            if (aranan.Contains("'"))
            {
                sql +=" where 1=-1";
                return sql;
            }

            if (aranan.Length == 0) return sql + sortParam;

            PropertyInfo[] p = _entity.GetProperties();

            string sqlWhere = "";

            foreach (var prop in p)
            {


                var NotMappadİşaretliMi = prop.GetCustomAttribute(typeof(NotMappedAttribute), false);
                if (NotMappadİşaretliMi != null || (prop.Name == "Item")) continue;

                string colSql = "";


                Type objType = prop.PropertyType; string columnName = prop.Name;


              

                if (prop.PropertyType == typeof(string))
                    colSql = prop.Name + " like '%" + aranan + "%' or ";
                else if (prop.PropertyType == typeof(DateTime?))
                {
                    colSql = "FORMAT(" + prop.Name + ", 'dd.MM.yyyy HH:ss') like '%" + aranan + "%' or ";
                }
                else if (prop.PropertyType == typeof(Guid))
                { ;}
                else
                    colSql = "convert(varchar(24)," + prop.Name + ") like '%" + aranan + "%' or ";

                if (tamEşleşmeMi==1)
                    colSql = colSql.Replace("like", "=").Replace("%", "");


                sqlWhere += colSql;
            }


            sql = sql + " where " + sqlWhere.Substring(0, sqlWhere.Length - 4);

            return sql + sortParam; 
        }

    }
}
