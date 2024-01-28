// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Cinemachine;
using Depra.Ecs.Hybrid.Components;
using Depra.Ecs.Hybrid.Entities;
using Depra.Ecs.QoL.Worlds;
using Depra.Ecs.Worlds;
using UnityEngine;
using static Depra.Ecs.Components.Cinemachine.Authoring.Module;

namespace Depra.Ecs.Components.Cinemachine.Authoring
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(CinemachineVirtualCameraRef), DEFAULT_ORDER)]
	public sealed class CameraAuthoringComponent : MonoBehaviour, IAuthoring
	{
		[SerializeField] private CinemachineVirtualCameraBase _value;

		IBaker IAuthoring.CreateBaker() => new Baker(this);

		private readonly struct Baker : IBaker
		{
			private readonly CameraAuthoringComponent _component;

			public Baker(CameraAuthoringComponent component) => _component = component;

			void IBaker.Bake(IAuthoring authoringEntity, World world)
			{
				if (((IAuthoringEntity) authoringEntity).Unpack(out var entity))
				{
					world.Pool<CinemachineVirtualCameraRef>().Allocate(entity).Value = _component._value;
				}
			}
		}
	}
}