using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;

namespace MyApi.Models
{
    public class MBase
    {
        [Key]
        [Browsable(false)]
        public int id { get; set; }

        #region 扩展方法


        /// <summary>
        /// model 转字典
        /// 如果数字类型,值为0 不加入转换20180129 ltw
        /// 控制计入运算，null不计入 2019 0424 ltw
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> ToDic()
        {
            Dictionary<string, string> dicTemp = new Dictionary<string, string>();
            PropertyInfo[] propertys = this.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                if (property.Name == "id")
                {
                    continue;
                }
                //|| property.GetValue(this,null).ToString()==""
                if (property.GetValue(this, null) == null)
                {
                    continue;
                }

                if (property.PropertyType == typeof(string) || property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(bool))
                {
                    dicTemp.Add(property.Name, "'" + property.GetValue(this, null).ToString().Replace("'", "''") + "'");
                }
                else
                {
                    if (property.GetValue(this, null).ToString() != "0")
                    {
                        dicTemp.Add(property.Name, property.GetValue(this, null).ToString());
                    }
                }
            }
            return dicTemp;
        }
        /// <summary>
        /// 初始化时吧NULL转空
        /// </summary>
        public virtual void NUllToEmpty()
        {
            PropertyInfo[] propertys = this.GetType().GetProperties();
            object value = "";
            foreach (PropertyInfo property in propertys)
            {
                if (property.GetValue(this, null) != null)
                {
                    continue;
                }
                else if (property.PropertyType==typeof(byte[]))
                {
                    continue;
                }
                else
                {
                    property.SetValue(this, value, null);
                }
            }
        }

        /// <summary>
        /// 初始化时吧NULL转空
        /// 不为null 只为空，转为null
        /// </summary>
        public virtual void EmptyToNull()
        {
            PropertyInfo[] propertys = this.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                if (property.GetValue(this, null) != null && property.GetValue(this, null).ToString() == "")
                {
                    property.SetValue(this, null, null);
                }
            }
        }

        /// <summary>
        /// ltw 20180206 修改,可以复制id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="copy"></param>
        public virtual void Copy<T>(T copy) where T : MBase
        {
            PropertyInfo[] propertys = this.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                object value;
                value = property.GetValue(this, null);
                property.SetValue(copy, value, null);
            }
            copy.id = this.id;
        }
        /// <summary>
        /// 有待改进
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T Copy<T>() where T : MBase, new()
        {
            PropertyInfo[] propertys = this.GetType().GetProperties();
            T temp = new T();
            foreach (PropertyInfo property in propertys)
            {
                object value;
                value = property.GetValue(this, null);
                property.SetValue(temp, value, null);
            }
            // temp.id = this.id;
            return temp;
        }

        /// <summary>
        /// dataRow 初始化
        /// </summary>
        /// <param name="dataRow"></param>
        public virtual void InitByDataRow(DataRow dataRow)
        {
            this.NUllToEmpty();
            PropertyInfo[] propertys = this.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                if (dataRow.Table.Columns.Contains(property.Name) && dataRow[property.Name] != System.DBNull.Value)
                {
                    property.SetValue(this, dataRow[property.Name], null);
                }
            }
            if (dataRow["id"] != null && dataRow["id"].ToString() != "")
            {
                id = Convert.ToInt32(dataRow["id"]);
            }
        }

        /// <summary>
        /// 情况属性值
        /// 2019 04 26 修改，如果是数字类型，设置为0
        /// </summary>
        public virtual void Clear()
        {
            PropertyInfo[] propertys = this.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                if (property.PropertyType == typeof(int) || property.PropertyType == typeof(double) || property.PropertyType == typeof(float))
                {
                    property.SetValue(this, (object)0, null);
                }
                else
                {
                    property.SetValue(this, null, null);
                }
            }
            //NUllToEmpty();
        }

        /// <summary>
        /// 属性值都设为null 方便重新设置 用于sql查询
        /// </summary>
        public virtual void ClearAllToNull()
        {
            PropertyInfo[] propertys = this.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                property.SetValue(this, null, null);
            }
            //NUllToEmpty();
        }

        /// <summary>
        /// 判断是null 或控
        /// </summary>
        /// <returns></returns>
        public virtual bool IsNullOrEmpty()
        {
            PropertyInfo[] propertys = this.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                if (property.GetValue(this, null) != null && property.GetValue(this, null).ToString() != "")
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}