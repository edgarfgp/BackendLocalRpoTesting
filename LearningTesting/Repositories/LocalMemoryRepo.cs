﻿using LearningTesting.DataModel;
using LearningTesting.Extensions;
using LearningTesting.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearningTesting.Repositories
{
    public class LocalMemoryRepo : IDatabaseRepo, IDatabaseRepo4Admin
    {



        public static List<ObjectBase> list = new List<ObjectBase>();



        public void Add<T>(T item) where T : ObjectBase
        {
            list.Add(item);
        }

        Task<T> IDatabaseRepo.Create<T>(T document)
        {
            var i = list.Find(n => n.Id.Equals(document.Id));

            if (i == null)
            {
                var cloned = document.CloneBySerialization();
                UpdateBaseObject(Guid.NewGuid(), cloned);

                list.Add(cloned);

                return Task.FromResult(cloned);
            }
            else
            {

                throw new ArgumentException("Key already present in database.");

                //return null;
            }
        }

        Task<T> IDatabaseRepo.Update<T>(Guid Id, T document)
        {
            ObjectBase o = list.Find(n => n.Id == Id);

            if (o == null)
                //object not "found"
                throw new Exception("Object to update not found");

            list.Remove(o);

            var cloned = document.CloneBySerialization();

            UpdateBaseObject(Id, cloned);

            list.Add(cloned);

            return Task.FromResult(cloned);
        }

        Task<bool> IDatabaseRepo.Delete<T>(Guid Id)
        {
            var ret = false;

            ObjectBase doc = list.Find(n => n.Id == Id);

            ret = doc != null;

            if (ret)
                list.Remove(doc);

            return Task.FromResult(ret);
        }

        Task<int> IDatabaseRepo.DeleteAll<T>()
        {
            return Task.FromResult(list.RemoveAll(n => n.Class == typeof(T).Name));
        }

        Task<T> IDatabaseRepo.Get<T>(Guid Id)
        {
            var doc = (T)(object)list.Find(d => d.Id == Id);

            //not found
            if (doc == null)
                return Task.FromResult(default(T));

            //mismatching class
            if (!(doc.Class == typeof(T).Name))
                return Task.FromResult(default(T));

            //return (T)doc;
            return Task.FromResult(doc.CloneBySerialization<T>());
        }

        Task<IEnumerable<T>> IDatabaseRepo.Get<T>()
        {
            var l1 = list.Where(n => n.Class == typeof(T).Name);

            var l2 = l1.Cast<T>();

            var l3 = l2.CloneBySerialization();

            return Task.FromResult(l3);
        }

        Task<IEnumerable<T>> IDatabaseRepo.Get<T>(Expression<Func<T, bool>> predicate)
        {
            var l1 = list.Where(n => n.Class == typeof(T).Name);

            var func = predicate.Compile();

            var l2 = l1.Cast<T>();

            var l3 = l2.Where(n => func(n));

            var l4 = l3.CloneBySerialization();

            return Task.FromResult(l4);
        }

        Task<IEnumerable<T>> IDatabaseRepo.Get<T>(Expression<Func<T, bool>> predicate1, Expression<Func<T, bool>> predicate2)
        {
            var l1 = list.Where(n => n.Class == typeof(T).Name);

            var func1 = predicate1.Compile();
            var l2 = l1.Cast<T>();

            var l3 = l2.Where(n => func1(n));

            var func2 = predicate2.Compile();

            var l4 = l3.Where(n => func2(n));
            var l5 = l4.Cast<T>();

            var l6 = l5.CloneBySerialization();

            return Task.FromResult(l6);
        }

        Task IDatabaseRepo4Admin.ClearRepo()
        {
            list.Clear();
            return Task.FromResult(0);
        }

        //private
        private static void UpdateBaseObject<T>(Guid id, T object2Update) where T : ObjectBase
        {
            object2Update.Id = id;
            object2Update.Class = typeof(T).Name;
        }
    }
}
