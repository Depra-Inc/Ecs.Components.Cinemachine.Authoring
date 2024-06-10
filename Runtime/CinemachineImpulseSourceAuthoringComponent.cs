// SPDX-License-Identifier: Apache-2.0
// © 2024 Evgeniy Kraevskiy <e.craevsky@depra.org>

using Cinemachine;
using Depra.Ecs.Hybrid.Components;
using Depra.Ecs.Hybrid.Entities;
using Depra.Ecs.QoL.Worlds;
using Depra.Ecs.Weapon.ShootingCameraShake.Authoring;
using Depra.Ecs.Worlds;
using UnityEngine;

namespace Depra.Ecs.Weapon.Shooting.CameraShake.Authoring
{
    [DisallowMultipleComponent]
    [AddComponentMenu(MENU_PATH + nameof(ImpulseSourceRef), DEFAULT_ORDER)]
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
                    world.Pool<ImpulseSourceRef>().Allocate(entity).Value = _component._value;
                }
            }
        }
    }
}
