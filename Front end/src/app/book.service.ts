import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookService {
 
  
  
 
  httpClient:HttpClient
  //ProductService class is dependent on HttpClient
  //Dependancy Injection
  //Angular will inject an object of httpclient
  //while creating object of this class

  constructor(httpClient:HttpClient) { 
    this.httpClient=httpClient
    }

    getBooks(){
      const url='http://localhost:58338/api/Books'
      const request=this.httpClient.get(url)
      return request
    }

    
    getBooksDetails(Book_id:number){
      const url='http://localhost:58338/api/Books'
      const request=this.httpClient.get(url+"/"+Book_id)
      return request
    }

    DeleteBook(Book_id:number) {
      const url='http://localhost:58338/api/Books'
      return this.httpClient.delete(url+"?book_id="+Book_id)
    }

   
/* 
    uploadFile(selectedFile: File,user:UserDetails) {
      const uploadData = new FormData();
      uploadData.append("imageFile", selectedFile);
      console.log(`sending ${user}`);
    //  const userDtls=new UserDetails("madhura@gmail",27);
     // uploadData.append("dtls", "{'email' : 'rama@gmail.com','age' : 27}");
     uploadData.append("dtls",JSON.stringify(user));
     return this.http.post(this.baseURL.concat("upload"), uploadData, { responseType: 'text' });
    }
 */
    updateBook(Book_id:number, Title: string, Description: string, ISBN: string, Price: number, count: number, Author: string) {
      
      const body={
        Book_id:Book_id,
        Title:Title,
        Price:Price,
        Author:Author,
        ISBN:ISBN,
        count:count,
        Description:Description
        } 
         
        const url='http://localhost:58338/api/Books'
      const request=this.httpClient.put(url+"/"+Book_id,body)
      return request


    }

    addBook(Title: string, Description: string, ISBN: string, Price: number, count: number, Author: string, selectedFile: File) {
     console.log('in UploadImage')
      const uploadData = new FormData();
      uploadData.append("imageFile", selectedFile);
      const url='http://localhost:58338/api/Books'
      const book = {
        Title:Title,
        Description:Description,
        Price:Price,
        Author:Author,
        ISBN:ISBN,
        count:count
      }
      const body={
        Book: book,
        uploadData: uploadData
      }
     
      const request=this.httpClient.post(url+"/",body)
      return request
    }
    /* addBook(title:string,description:string,price:number,author:string,isbn:string,count:number,selectedFile: File){
      const uploadData = new FormData();
      uploadData.append("imageFile", selectedFile);
      const url='http://localhost:7071/books'
      const body={
        Title:title,
        Description:description,
        Price:price,
        Author:author,
        ISBN:isbn,
        count:count

      }
      uploadData.append("dtls",JSON.stringify(body));
      return this.httpClient.post(url,uploadData,{ responseType: 'text' })
    } 
  */
    insertBook(Title: string, Description: string, ISBN: string, Price: number, count: number, Author: string) {
      
      const body={
          
        Title:Title,
        Price:Price,
        Author:Author,
        ISBN:ISBN,
        count:count,
        Description:Description
        } 
         
        const url='http://localhost:58338/api/Books'
      const request=this.httpClient.post(url+"/",body)
      return request


    }
  



  }
