﻿// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using Depra.Ecs.Hybrid;
using Depra.Ecs.QoL;
using Unity.Cinemachine;
using UnityEngine;
using static Depra.Ecs.Components.Cinemachine.Authoring.Module;

namespace Depra.Ecs.Components.Cinemachine.Authoring
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(CinemachineVirtualCameraBaseRef), DEFAULT_ORDER)]
	internal sealed class CinemachineVirtualCameraBaseAuthoringComponent : MonoBehaviour, IAuthoring
	{
		[SerializeField] private CinemachineVirtualCameraBase _value;

		IBaker IAuthoring.CreateBaker() => new Baker(this);

		private readonly struct Baker : IBaker
		{
			private readonly CinemachineVirtualCameraBaseAuthoringComponent _component;

			public Baker(CinemachineVirtualCameraBaseAuthoringComponent component) => _component = component;

			void IBaker.Bake(IAuthoring authoringEntity, World world)
			{
				if (((IAuthoringEntity)authoringEntity).Unpack(out var entity))
				{
					world.Pool<CinemachineVirtualCameraBaseRef>().Allocate(entity).Value = _component._value;
				}
			}
		}
	}
}