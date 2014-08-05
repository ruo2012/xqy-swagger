grammar Xqy;

@parser::members
{
    protected const int EOF = Eof;
}
 
@lexer::members
{
    protected const int EOF = Eof;
    protected const int HIDDEN = Hidden;
}

/*
 * Parser Rules
 */

prog: expr* EOF ;

expr: DECL expr												# FnDecl
	| RXQ 'PUT' expr										# PutVerb
	| RXQ 'GET' expr										# GetVerb
	| RXQ 'POST' expr										# PostVerb
	| RXQ PATH LPAREN expr RPAREN expr						# UrlInBraces
	| '\'' expr '\''										# quotes
	| URI													# UrlPath
	;

/*
 * Lexer Rules
 */
URISEP : '/' ;
WS    :  [ \t\r\n]+ -> skip ;
XQRY : 'xquery version "1.0-ml";' -> skip ;
MODULE : 'module ' .*? ';' -> skip ;
DECL : 'declare' ;
DECLNMSP : DECL WS ('namespace'|'default'|'option') .*? ';' -> skip ;
IMPRT  : 'import' .*? ';' -> skip ;
FNBODY : 'function' .*? '};' -> skip ;
LPAREN : '(' ;
RPAREN : ')' ;
RXQ   : '%rxq:' ;
PATH  : 'path' ;
URI   : URISEP ALPHA (DIGIT|ALPHA|URISEP)* URISEP ;
COMMENT : '(:' .*? ':)' -> skip ;

fragment
ALPHA : [a-zA-Z] ;

fragment
DIGIT : [0-9] ;


