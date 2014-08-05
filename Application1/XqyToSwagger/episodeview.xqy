xquery version "1.0-ml";

module namespace episodeview = "https://bbcw/ods/episodeview";
declare namespace content="http://bbc.ww/common/content/v1.0";
declare namespace rxq="http://exquery.org/ns/restxq";

import schema "http://bbc.ww/common/content/v1.0" at "/canonical_schemas_content/Episode.xsd";
import module namespace dal = "https://bbcw/ods/dal" at "/modules/dal.xqy";
import module namespace common = "https://bbcw/ods/common" at "/modules/common.xqy";

declare option xdmp:mapping "false";

declare function episodeview:store($contentNode) as item()*
{
	try {
	let $_ := xdmp:log("start validate of message..")
	let $incomingMessageTypeName := fn:local-name-from-QName( $contentNode/sc:type()!sc:name() )
	let $validationErrors := xdmp:validate( $contentNode, "type", fn:QName("http://bbc.ww/common/content/v1.0", "EpisodeType") )
	return
	  (
		if ( $incomingMessageTypeName = "untyped" )
		then ( common:create-response-message(200, "OK", "2700605", "Unknown Message Type") )
		else (
			if (  fn:string-length(  $validationErrors/string() ) > 0  )
			then ( common:create-response-message(200, "OK", "2700605", $validationErrors)  )
			else ( dal:store-content("episode", $contentNode, $contentNode/content:Code) ) 
		)
	  )
	}
	catch ($e) {
		common:create-response-message(200, "OK", "2700500", $e)
	}
	
};

declare
  %rxq:PUT
  %rxq:path('/v1/content/episode/')
function episodeview:store-episode() as item()*
{
	let $contentNode := xdmp:get-request-body()/node()
	return episodeview:store($contentNode)
};


