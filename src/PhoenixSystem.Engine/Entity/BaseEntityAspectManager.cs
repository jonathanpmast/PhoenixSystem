﻿using System.Collections.Generic;
using PhoenixSystem.Engine.Aspect;
using PhoenixSystem.Engine.Component;

namespace PhoenixSystem.Engine.Entity
{
    public abstract class BaseEntityAspectManager : IEntityAspectManager
    {    
        public abstract void ComponentAddedToEntity(IEntity e, IComponent component);
        public abstract void ComponentRemovedFromEntity(IEntity e, IComponent component);
        public abstract IEnumerable<TAspectType> GetAspectList<TAspectType>() where TAspectType : IAspect, new();
        public abstract IEnumerable<TAspectType> GetUnfilteredAspectList<TAspectType>() where TAspectType : IAspect, new();
        public abstract void RegisterEntity(IEntity e);
        public abstract void ReleaseAspectList<TAspectType>();        
        public abstract void UnregisterEntity(IEntity e);
    }
}