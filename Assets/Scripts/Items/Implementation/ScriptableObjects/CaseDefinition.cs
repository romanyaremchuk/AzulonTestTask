using System.Collections.Generic;
using UnityEngine;

namespace Items.Implementation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemDefinition", menuName = "Game/Items/Case Definition")]
    public class CaseDefinition : ItemDefinitionBase
    {
        [SerializeField] private List<WeaponDefinition> _weaponDefinitions;

        public List<WeaponDefinition> WeaponDefinitions => _weaponDefinitions;
    }
}
