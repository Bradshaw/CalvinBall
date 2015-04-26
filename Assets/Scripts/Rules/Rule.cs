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

<<<<<<< HEAD
public class Rule : MonoBehaviour 
{ 
	public override string ToString ()
	{
		return "NORULE|NOTYPE";
	}

=======
public class Rule : MonoBehaviour {

    public override string ToString()
    {
        return "NORULE";
    }
>>>>>>> 848c614de2c11a54bbc5169d8f28268c7858eeed

}
