using UnityEngine;
using System.Collections;

public enum RuleType
{
    nil,
    points,
    foul,
    finisher,
    constraint
}

public class Rule : MonoBehaviour {
    public const string name = "NORULE";
    public const RuleType type = RuleType.nil;

}
