using UnityEngine;

public class Arraste : MonoBehaviour
{
    void OnMouseDrag()
	{
		float posicaoEmZObjetoNaTela = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 posicaoObjetoNaTela = new Vector3(Input.mousePosition.x, Input.mousePosition.y, posicaoEmZObjetoNaTela);

        Vector3 posicaoObjetoNoMundo = Camera.main.ScreenToWorldPoint(posicaoObjetoNaTela);

		transform.position = posicaoObjetoNoMundo;

	}
    
}
