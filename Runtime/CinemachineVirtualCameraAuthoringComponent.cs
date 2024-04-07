// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Cinemachine;
using Depra.Ecs.Hybrid.Components;
using Depra.Ecs.Hybrid.Entities;
using Depra.Ecs.QoL.Components;
using Depra.Ecs.Worlds;
using UnityEngine;
using static Depra.Ecs.Components.Cinemachine.Authoring.Module;

namespace Depra.Ecs.Components.Cinemachine.Authoring
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(CinemachineVirtualCameraRef), DEFAULT_ORDER)]
	public sealed class CinemachineVirtualCameraAuthoringComponent : MonoBehaviour, IAuthoring
	{
		[SerializeField] private CinemachineVirtualCamera _value;

		IBaker IAuthoring.CreateBaker() => new Baker(this);

		private readonly struct Baker : IBaker
		{
			private readonly CinemachineVirtualCameraAuthoringComponent _component;

			public Baker(CinemachineVirtualCameraAuthoringComponent component) => _component = component;

			void IBaker.Bake(IAuthoring authoringEntity, World world)
			{
				if (((IAuthoringEntity) authoringEntity).Unpack(out var entity))
				{
					world.Pools.Get<CinemachineVirtualCameraRef>().Allocate(entity).Value = _component._value;
				}
			}
		}
	}
}