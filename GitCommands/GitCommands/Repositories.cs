﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace GitCommands
{
    public static class Repositories
    {
        public static string SerializeRepositories()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<RepositoryCategory>));
            serializer.Serialize(sw, RepositoryCategories);
            return sw.ToString();
        }

        public static void DeserializeRepositories(string xml)
        {
         XmlSerializer serializer = new XmlSerializer(typeof(BindingList<RepositoryCategory>));
         using (StringReader stringReader = new StringReader(xml))
         using (XmlTextReader xmlReader = new XmlTextReader(stringReader))
         {
             BindingList<RepositoryCategory> obj = serializer.Deserialize(xmlReader) as BindingList<RepositoryCategory>;
             if (obj != null)
                 RepositoryCategories = obj;
         }
        }

        public static string SerializeHistory()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(RepositoryHistory));
            serializer.Serialize(sw, RepositoryHistory);
            return sw.ToString();
        }

        public static void DeserializeHistory(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RepositoryHistory));
            using (StringReader stringReader = new StringReader(xml))
            using (XmlTextReader xmlReader = new XmlTextReader(stringReader))
            {
                RepositoryHistory obj = serializer.Deserialize(xmlReader) as RepositoryHistory;
                if (obj != null)
                    RepositoryHistory = obj;
            }
        }

        static Repositories()
        {
            RepositoryHistory = new RepositoryHistory();
            RepositoryCategories = new BindingList<RepositoryCategory>();
        }

        public static RepositoryHistory RepositoryHistory { get; private set; }

        public static BindingList<RepositoryCategory> RepositoryCategories { get; private set; }

        public static void AddCategory(string title)
        {
            RepositoryCategory repositoryCategory = new RepositoryCategory();
            repositoryCategory.Description = title;
            RepositoryCategories.Add( repositoryCategory);
        }
    }
}