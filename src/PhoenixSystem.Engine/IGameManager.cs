﻿using PhoenixSystem.Engine.Events;
using System;
using System.Collections.Generic;

namespace PhoenixSystem.Engine
{
    public interface IGameManager
    {
        IEntityManager EntityManager { get; }
        
        IDictionary<int, ISystem> Systems { get; }
        IDictionary<int, IManager> Managers { get; }
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
        void RemoveSytem(ISystem system, bool shouldNotify);
        void RemoveAllSystems(bool shouldNotify);
        event EventHandler SystemSuspended;
        void SuspendSystem(ISystem system);
        event EventHandler SystemStarted;
        void StartSystem(ISystem system);
        IEnumerable<IAspect> GetAspectList<AspectType>() where AspectType : IAspect, new();
        IEnumerable<IAspect> GetUnfilteredAspectList<AspectType>() where AspectType : IAspect, new();
        void ReleaseAspectList<AspectType>();
        void RegisterManager(IManager manager);
    }
}