﻿using System;
using System.Collections.Generic;
using PhoenixSystem.Engine.Channel;
using PhoenixSystem.Engine.Component;
using PhoenixSystem.Engine.Events;

namespace PhoenixSystem.Engine.Entity
{
    public interface IEntity : IChannelFilterable
    {
        Guid ID { get; }
        bool IsDeleted { get; set; }
        IDictionary<string, IComponent> Components { get; }
        string Name { get; set; }
        event EventHandler Deleted;
        void Delete();        
        IEntity Clone();
        bool HasComponent(Type componentType);
        bool HasComponent(string componentTypeName);
        bool HasComponents(IEnumerable<Type> types);
        bool HasComponents(IEnumerable<string> types);
        event EventHandler<ComponentChangedEventArgs> ComponentAdded;
        IEntity AddComponent(IComponent component, bool shouldOverwrite = false);        
        event EventHandler<ComponentChangedEventArgs> ComponentRemoved;
        bool RemoveComponent(Type componentType);
        bool RemoveComponent(string componentType);
    }
}