using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int HP;

    public Player(int hp) => Name = hp;

    public int Name
    {
        get => HP;
        set => HP = value;
    }
}