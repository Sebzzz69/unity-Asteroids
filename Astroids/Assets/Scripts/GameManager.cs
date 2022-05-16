using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public float respawnTime = 3.0f;
    public float respawnInvunlnerabilityTime = 3.0f;

    public int lives = 3;

    public void PlayerDied()
    {
        this.lives--;

        if (this.lives <= 0){
            GameOver();
        } else
        {
            Invoke(nameof(Respawn), respawnTime);
        }

    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        
        Invoke(nameof(TurnOnCollisions), respawnInvunlnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        // TODO
    }

}
