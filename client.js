/*CLIENT
1)Leggere la configurazione
2)Aprire la connessione
3)Recuperare l'ultimo id nel database
4)Verificare se l'id del database è maggiore di quello conservato nel file di configurazione
5)Se è maggiore eseguire la seguente procedura:
	connettersi ai vari server per recuperare l'ultimo id
		recuperare i record di gedamaga e inviare i record mancanti 
		restituire l'ultimo id inserito
        storicizzare nei file di configurazione l'id restituito.
*/
const odbc = require('odbc')



var conf = require("./config.json")
var cnf = require("./config.js")
var param = new cnf("./config.json")
var codice= param.get("ultimoCodice", 100)
var cn = param.get("connessione", "DSN=jeda_sim")


var ultimoId= readId();
console.log(ultimoId)
console.log("L'ultimo id è : "+codice)
async function readId(){
    try {
        const db = await odbc.connect(cn)
        var strQuery="select max(codice_articolo) as ultimo_id from gedamaga"
        await db.beginTransaction()
        const data = await db.query(strQuery)
		await db.commit()
		var id = data[0].ultimo_id
		console.log("id database corrente : "+id)
    } catch(err){
        console.log("errore")
		console.error(err)
    }

}