using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class Controller : MonoBehaviour
{
    HttpClient client = new HttpClient();

    public GameScript game;
    
    private async Task Update()
    {
        await GetTodoItems();
    }

    private async Task GetTodoItems()
    {
        string respense = await client.GetStringAsync("https://lys-installation-website-32gsd.ondigitalocean.app/control");

        if (respense == "up" && game.playerDirection != 3)
            game.setDirection(1);
        else if (respense == "down" && game.playerDirection != 1)
            game.setDirection(3);
        else if (respense == "left" && game.playerDirection != 4)
            game.setDirection(2);
        else if (respense == "right" && game.playerDirection != 2)
            game.setDirection(4);
    }
}
