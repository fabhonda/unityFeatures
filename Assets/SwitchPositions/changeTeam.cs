using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ChangeTeam : MonoBehaviour
{

    public int speed = 1;
    private bool move = false;
    public List<GameObject> players;
    private int selected = 0;
    public List<GameObject> selectedPlayers;
    private List<Vector3> positions = new List<Vector3>();

    void Update()
    {
        if (move)
        {
            var step = 8f * Time.deltaTime * speed;
            selectedPlayers[0].transform.position = Vector3.MoveTowards
                (selectedPlayers[0].transform.position, positions[1], step);
            selectedPlayers[1].transform.position = Vector3.MoveTowards
                (selectedPlayers[1].transform.position, positions[0], step);
            if (selectedPlayers[1].transform.position == positions[0] &&
                selectedPlayers[0].transform.position == positions[1])
            {
                move = false;
                for (int i = 0; i < selectedPlayers.Count; i++)
                {
                    selectedPlayers[i].GetComponent<Player>().selected = false;
                }
                selectedPlayers.Clear();
                positions.Clear();
                selected = 0;
            }
        }
    }

    public void selectPlayer(int id)
    {
        if (!move)
        {
            if (!players[id].GetComponent<Player>().selected)
            {
                if (selected == 1)
                {
                    selectedPlayers.Add(players[id]);
                    selectedPlayers[0].GetComponent<Image>().color = new Color(0, 0, 0);
                    for (int i = 0; i < selectedPlayers.Count; i++)
                    {
                        positions.Add(selectedPlayers[i].transform.position);
                    }
                    move = true;
                }
                else
                {
                    players[id].GetComponent<Player>().selected = true;
                    players[id].GetComponent<Image>().color = new Color(78, 0, 255);
                    selected++;
                    selectedPlayers.Add(players[id]);
                }
            
            }
            else
            {
                players[id].GetComponent<Player>().selected = false;
                players[id].GetComponent<Image>().color = new Color(0, 0, 0);
                selected--;
                selectedPlayers.Remove(players[id]);
            }
        }
     
    }
}