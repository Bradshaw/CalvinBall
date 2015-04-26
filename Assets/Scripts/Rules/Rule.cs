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

public class Rule : MonoBehaviour 
{ 
	public override string ToString ()
	{
		return "NORULE|NOTYPE";
	}

}
