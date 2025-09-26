using System.Transactions;
using UnityEngine;

public interface IPlayerStrategy
{
    void Jump();
    void Roll();
    void Run();
}