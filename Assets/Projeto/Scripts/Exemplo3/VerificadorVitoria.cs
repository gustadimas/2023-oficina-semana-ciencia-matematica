using UnityEngine;

public class VerificadorVitoria : MonoBehaviour
{
    public Associacao[] locaisDeAssociacao;
    public GameObject objetoAtivar;

    int quantidadeDePecasNoLugar = 0;

    void Update() {
        if(locaisDeAssociacao.Length == 0) return;

        if(quantidadeDePecasNoLugar == locaisDeAssociacao.Length)
            objetoAtivar.SetActive(true);
    }

    public void RegistrarPecaNoLugar(){
        quantidadeDePecasNoLugar++;
    }
}
