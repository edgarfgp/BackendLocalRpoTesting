﻿using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace LearningTesting.Helpers
{
    public static class ContainerExtensions
    {
        /// <summary> 
        /// Register repository by type on unity container
        /// </summary>
        /// <typeparam name="I">Interface to register.</typeparam>
        /// <typeparam name="T">Type to register.</typeparam>
        /// <param name="container">Unity container to use.</param>
        public static void RegisterRepo<I, T>(this IUnityContainer container) where T : I
        {
            container.RegisterType<I, T>();

        }

        /// <summary>
        /// Register repository by type on unity container
        /// </summary>
        /// <typeparam name="I">Interface to register.</typeparam>
        /// <typeparam name="T">Type to register.</typeparam>
        /// <param name="container">Unity container to register to.</param>
        /// <param name="lifetimeManager"><see cref="LifetimeManager"/> instance to govern the object life cycle.</param>
        public static void RegisterRepo<I, T>(this IUnityContainer container, LifetimeManager lifetimeManager) where T : I
        {
            container.RegisterType<I, T>(lifetimeManager);
   
        }

        /// <summary>
        /// Register repository by instance on unity container
        /// </summary>
        /// <typeparam name="I">Interface to register.</typeparam>        
        /// <param name="container">Unity container to use.</param>
        /// <param name="instance">The instance of the object</param>
        public static void RegisterRepoInstance<I>(this IUnityContainer container, I instance)
        {
            container.RegisterInstance<I>(instance);
        }

        /// <summary>
        /// Register service in dependency injection container
        /// </summary>
        /// <typeparam name="I">Interface to register.</typeparam>
        /// <typeparam name="T">Type to register.</typeparam>
        /// <param name="container">Unity container to use.</param>
        public static void RegisterService<I, T>(this IUnityContainer container) where T : I
        {
            container.RegisterType<I, T>();
           
        }

        /// <summary>
        /// Register service in dependency injection container
        /// </summary>
        /// <typeparam name="I">Interface to register.</typeparam>
        /// <typeparam name="T">Type to register.</typeparam>
        /// <param name="container">Unity container to use.</param>
        /// <param name="lifetimeManager"><see cref="LifetimeManager"/> instance to govern the object life cycle.</param>
        public static void RegisterService<I, T>(this IUnityContainer container, LifetimeManager lifetimeManager) where T : I
        {
            container.RegisterType<I, T>(lifetimeManager);

        }
    }
}
