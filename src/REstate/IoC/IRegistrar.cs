﻿using System;

namespace REstate.IoC
{
    /// <summary>
    /// Registration functionality for IoC.
    /// </summary>
    public interface IRegistrar
    {
        /// <summary>
        /// Registers the specified instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="name">The name under which an implmentation was registered.</param>
        void Register<T>(T instance, string name = null)
            where T : class;

        /// <summary>
        /// Registers the specified type to an implementation type.
        /// </summary>
        /// <typeparam name="TBinding">The type to register.</typeparam>
        /// <typeparam name="TImplementation">The implementation to which the binding resolves.</typeparam>
        /// <param name="name">The name under which an implmentation was registered.</param>
        void Register<TBinding, TImplementation>(string name = null)
            where TBinding : class 
            where TImplementation : class, TBinding;

        /// <summary>
        /// Registers the specified type to an implementation type.
        /// </summary>
        /// <param name="name">The name under which an implmentation was registered.</param>
        /// <param name="registrationType">The type to register.</param>
        /// <param name="implementationType">The implementation to which the binding resolves.</param>
        void Register(Type registrationType, Type implementationType, string name = null);

        /// <summary>
        /// Registers the specified factory method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resolver">The resolver.</param>
        /// <param name="name">The name under which an implmentation was registered.</param>
        void Register<T>(Func<IComponentContainer, T> resolver, string name = null)
            where T : class;

        /// <summary>
        /// Registers a component and all of it's associated dependencies.
        /// </summary>
        /// <param name="component">The component to register.</param>
        void RegisterComponent(IComponent component);
    }

}