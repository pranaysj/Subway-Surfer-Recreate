using System.Transactions;
using UnityEngine;

public interface IPlayerStrategy
{
    void Jump();
    void Roll(float yPosition, float ySize);
    void Run();
    void Dodge(DodgeDirection direction);
    void Fall();
}