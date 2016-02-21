﻿using System;
using System.Collections.Generic;
using PhoenixSystem.Engine.Events;

namespace PhoenixSystem.Engine
{
    public interface IGameManager
    {
        IEntityManager EntityManager { get; }
        
        IEnumerable<ISystem> Systems { get; }
        IEnumerable<IManager> Managers { get; }
        bool IsUpdating { get; }
        
        void Update(ITickEvent tickEvent);
        
        event EventHandler EntityAdded;        
        void AddEntity(IEntity e);
        void AddEntities(IEnumerable<IEntity> entities);
        void RemoveAllEntities();
        event EventHandler EntityRemoved;
        void RemoveEntity(IEntity e);
        event EventHandler SystemAdded;
        void AddSystem(ISystem system);
        event EventHandler SystemRemoved;
        void RemoveSystem<SystemType>(bool shouldNotify) where SystemType : ISystem;
        void RemoveAllSystems(bool shouldNotify);
        event EventHandler SystemSuspended;
        void SuspendSystem<SystemType>() where SystemType : ISystem;
        event EventHandler SystemStarted;
        void StartSystem<SystemType>() where SystemType : ISystem;
        IEnumerable<AspectType> GetAspectList<AspectType>() where AspectType : IAspect, new();
        IEnumerable<AspectType> GetUnfilteredAspectList<AspectType>() where AspectType : IAspect, new();
        void ReleaseAspectList<AspectType>();
        void RegisterManager(IManager manager);
    }
}