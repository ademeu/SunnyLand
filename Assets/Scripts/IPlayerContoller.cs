using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerContoller 
{
   float HorizontalAxis { get; }
   float VerticalAxis { get; }
   float JumpAxis { get; }
}
