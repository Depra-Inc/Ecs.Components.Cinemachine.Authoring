// SPDX-License-Identifier: Apache-2.0
// © 2024 Evgeniy Kraevskiy <e.craevsky@depra.org>

using Cinemachine;
using Depra.Ecs.Hybrid;
using Depra.Ecs.QoL;
using UnityEngine;
using static Depra.Ecs.Components.Cinemachine.Authoring.Module;

namespace Depra.Ecs.Components.Cinemachine.Authoring
{
    [DisallowMultipleComponent]
    [AddComponentMenu(MENU_PATH + nameof(CinemachineImpulseSourceRef), DEFAULT_ORDER)]
    public sealed class CinemachineImpulseSourceAuthoringComponent : MonoBehaviour, IAuthoring
    {
        [SerializeField] private CinemachineImpulseSource _value;
        
        IBaker IAuthoring.CreateBaker() => new Baker(this);
        
        private readonly struct Baker : IBaker
        { 
            private readonly CinemachineImpulseSourceAuthoringComponent _component;
            
            public Baker(CinemachineImpulseSourceAuthoringComponent component) => _component = component;
            
            void IBaker.Bake(IAuthoring authoring, World world)
            {
                if (((IAuthoringEntity) authoring).Unpack(out var entity))
                {
                    world.Pool<CinemachineImpulseSourceRef>().Allocate(entity).Value = _component._value;
                }
            }
        }
    }
}
