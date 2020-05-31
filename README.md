# dotnetcore-graphql
A very simple way of approaching APIs endpoints with graphql query language.

## # **Sample Queries**
**Query 1**

{"query":
 "query{ 
 	 Materials{
	Brand{
		Id
		Name
	}
 	Name
 	}
  }" 
}

**Query 2**

{"query":
 "query
 	{
 	MaterialByBrandId(Id:17){
 		Id
 		Name
 		Brand{
 			Id
 			Name
 		}
 	}
  }"
}

**Query 3**

{"query":
 "query
 	getMeterialByBrandId($Id:Int!){
 	MaterialByBrandId(Id:$Id){
 		Name
 		Brand{
 			Id
 			Name
 		}
 	}
  }" ,
   	"variables":{
   		"Id":18
   	}
}

**Query 4**

{"query":
 "query{ 
 	 PurchaseHistories{
 	 	Id
		Material{
			Id
			Name
			Piece
		}
		Date
		Amount
 	}
  }" 
}

**Query 5**

{"query":
 "query
 	getPurchaseHistoriesByMaterialId($Id:Int!){
 	PurchaseHistoriesByMaterialId(Id:$Id){
 		Id
		Material{
			Id
			Name
			Piece
		}
		Date
 	}
  }" ,
   	"variables":{
   		"Id":13
   	}
}

**Query 6**

{"query":
 "query
 	getPurchaseHistoriesByMaterialIdAndDate($Id:Int!, $Date:DateTime!){
 	PurchaseHistoriesByMaterialIdAndDate(Id:$Id, Date:$Date){
 		Id
		Material{
			Id
			Name
			Piece
		}
		Date
 	}
  }" ,
   	"variables":{
   		"Id":56,
   		"Date": "2020-05-27"
   	}
}
