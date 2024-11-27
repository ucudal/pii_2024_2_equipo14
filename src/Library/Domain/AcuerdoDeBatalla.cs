namespace Library;
// esto de aca seria el plan que hice para agregar las reglas personalizadas
/*
-Creo una clase AcuerdoDeBatalla para manejar las restricciones de la batalla
-Crear una lista de restricciones en AcuerdoDeBatalla
-Crear un método en la clase AcuerdoDeBatalla para hacer un acuerdo de restricciones
-El método tiene que agregar a la lista Nombre de pokemon,tipos de pokemon, ítems y al terminar mostrar todas las restricciones que hay.
-Modificar los métodos relacionados con agregarpokemon para que usen la lista como restricción con el estilo siguiente: Si nombre pokemon 
esta en la lista de restricciones entonces no se puede elegir ese pokemon y lo mismo para los tipos
-Modificar los métodos relacionados con el uso de ítems para que solo se puedan usar ítems que no esten en la lista de restricciones con el mismo estilo
 que el punto anterior.

-usar el método creado en la clase AcuerdoDeBatalla en la clase BattleCommand antes de empezar la batalla 

-Agregar Mensajes del estilo "el tipo de pokemon que quieres usar esta dentro de las restricciones por favor intente usar otro tipo de pokemon" y asi 
para el resto de las rstricciones 

-para que cada clase maneje lo que tenga que manejar tendria que agregar todos los mensajes en la clase Mensaje por ejemplo(agregar un mensaje 
para ver las restricciones que estan en la lista) y en la clase Facade tendria que hacer metodos para que devuelvan esos mensajes, 
esto tendria que ser igual a como interactua la clase AttackCommand 

- actualmente en el código agregamos los ítems de forma manual y no verificamos el tipo de pokemon sino que lo agregamos por nombre habría que 
modificar esos métodos para que se pueda poner restricciones para ellos ya que por ejemplo en el caso de los ítems se incilizan siempre los mismos,
o se podría poner restricciones de cuando lo va a usar en la batalla no lo deje y en el caso de los pokemones si son del tipo que hay en las restricciones
la vida pase a 0 automaticamente 
*/

public class AcuerdoDeBatalla
{ 
        public List<AcuerdoDeBatalla> InicializarAcuerdBatalla = new List<AcuerdoDeBatalla>(); // creo una lista para agregar las restricciones


    //Creo un metodo para agregar restricciones del tipo Nombre Pokemon,Tipos de Pokemon y items a la lista de restricciones
    public static void InicializarAcuerdoDeBatalla(Entrenador jugador1, Entrenador jugador2, string Pokemon, Item item,string Tipo)
    {     // tendria que esperar a que un usuario use el comando !battle para que se ejecute y ahi se decida las restricciones
          // estas restricciones se tendrian que agregar a la lista con un string de lo que ponga el usuario


              
        // me tranque con el metodo para poder ver lo que recibe del usuario y agregarlo a la lista
        
    }
}
/*
PORQUE NO PUDE COMPLETAR LA TAREA:
Siento que pude hacer un buen plan pero me llevo demasiado tiempo y que la tarea la logre resolver de forma correcta en la parte del armado de un plan 
sin embargo,al trancarme con el metodo para agregar las restricciones en la lista y no poder resolverlo es lo que me llevo a no completar la tarea 
ya que es lo principal de como interactua el usuario con las restricciones y sin eso no podia seguir haciendo el trabajo.
Creo que otra cosa que me llevo a no poder completar la tarea es no poder apoyarme en la IA para poder seguir con esto ya que la uso para cuando me tranco
con lo que estoy haciendo para que me genere una respuesta y poder ver de que forma podria hacerlo para usarla como base y ahorrar tiempo buscando 
por otros medios.
Otra cosa que me falto seria hacer los mensajes que esos si los podria haber hecho pero al concentrarme con la parte de como resolver lo del metodo para agregar las restricciones 
no los llegue a hacer, los mensajes son faciles de hacer seria poner los metodos vacios con un return que contenga el mensaje ya que la logica se trataria en la clase AcuerdoDeBatalla y 
en el metodo InicializarAcuerdoDeBatalla
*/