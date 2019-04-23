# Usefull documentation
1. https://www.oreilly.com/library/view/developing-with-pdf/9781449327903/ch01.html
2. https://blog.didierstevens.com/2008/05/19/pdf-stream-objects/
3. https://www.adobe.com/content/dam/acom/en/devnet/pdf/pdfs/PDF32000_2008.pdf
4. Images - https://learning.oreilly.com/library/view/developing-with-pdf/9781449327903/ch03.html
5. https://www.pdfscripting.com/public/PDF-Page-Coordinates.cfm 
6. http://lotabout.me/orgwiki/pdf.html 

# Basic Objects

1. Boolean value
1. Integer value
1. Real number
1. String
1. Names
1. Arrays
1. Dictionary
1. Streams
1. Null

#   Generic PDF Object Structure

```
  [object-number] [generation-number] obj /* Identifying info for this object **/
    <<   /* Start of object keys */
        /Type /[type-value] /* Type of this object */
        /[key] [value] /* Key value pairs for this object */
        /[key] /* Key with value as another object */
         << 
              [other-object]
         >>
        /[key] [object-number] [generation-number] R /* Key with value as reference to another object */
    >>   /* End of object keys */
  [stream]  /* Stream of data like text data etc. */
  endobj  /* End of object */
```

# Name objects
User / to start a name. / is followed by a string 

Rules for naming:
1. # written sa #23
1. Characters in a string can be written as it self or as 2 digit hexadecimal representation
1. Any non regular character is written as 2 digit hexadecimal preceded by #

Examples in Table 4 of documentation

# Arrays
One array can contain multiple types
[0 /type (dasd) 213]

# Dictionary Objects

This is dictionary `<<>>`

Example of more complicated dictionary:
```
<< /Type /Example  
>>
```

/Type is a name and it must always be a name
/Example is a value and can be anything even a new array

```
<< /Type /Example  
   /Subdictionary << /Item true
                     /Item2 1.2
                  >>
>>
```

More examples of dictionaries
```
% a more human-readable dictionary
<<
    /Type /Page
    /Author (Leonard Rosenthol)
    /Resources << /Font [ /F1 /F2 ] >>
>>

% a dictionary with all white-space stripped out
<</Length 3112/Subtype/XML/Type/Metadata>>
```

# Stream objects

```
<<
    /Type       /XObject
    /Subtype    /Image
    /Filter     /FlateDecode
    /Length     496
    /Height     32
    /Width      32
>>

stream
% 496 bytes of Flate-encoded data goes here...
endstream
```

# Direct vs Indirect objects

Indirect objects example:

```
3 0 obj        % object ID 3, generation 0
<<
 /ProcSet [ /PDF /Text /ImageC /ImageI ]
 /Font <<
     /F1 <<
        /Type /Font
        /Subtype /Type1
        /Name /F1
        /BaseFont/Helvetica
        >>
     >>
>>
endobj

5 0 obj
(an indirect string)
endobj

% an indirect number
4 0 obj
1234567890
endobj
```

# Text

# Text State Parameters
see Table 104 

## Text Object Operators
see Table 107
`BT` - Begin a text object
`ET` - End a text object

## Text positioning Operators
see Table 108
`Td` - Used for text positioning in a format `100 10 Td`
`Tm` -  Used for text positioning in a format `1 0 0 1 260 600 Tm`

## Text showing operators
`Tj` - Show a text string

# Font types
see Table 110 of PDF doc

Most relevant `Type1` uses type 1 dont technology

# Encoding Decoding Algorithms

1. ASCIIHexDecode
1. ASCII85Decode
1. LZWDecode
1. FlateDecode
1. RunLengthDecode
1. CCITTFaxDecode
1. JBIG2Decode
1. DCTDecode
1. JPXDecode
1. Crypt