using UnityEngine;

public class Associar : MonoBehaviour
{
    public Transform pecaCorretaTransform;
    public Arraste scriptArrastarDaPeca;
    bool pecaNoLugar = false;

    void Update()
    {
        if(pecaNoLugar) return;

        if(Vector2.Distance(transform.position, pecaCorretaTransform.position) < 0.25f)
        {
            // Ajusta a posição da peça para que ela fique exatamente no lugar correto.
            pecaCorretaTransform.position = transform.position;
     
            // Desativa o script de arraste e rotação da peça.
            Destroy(scriptArrastarDaPeca);                        
            
            // Registra que a peça está no lugar correto.
            pecaNoLugar = true;
        }
    }

}
