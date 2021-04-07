import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

export class friend {
  constructor(
    public id: number,
    public f_name: string,
    public m_name: string,
    public l_name: string,
    public address: string,
    public birthDate: string,
    public score: string,
    
  ){

  }
}

@Component({
  selector: 'app-friend',
  templateUrl: './friend.component.html',
  styleUrls: ['./friend.component.css']
})
export class FriendComponent implements OnInit {

  
  friend: any;
  closeResult: any;
  constructor(
    private HttpClient: HttpClient,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.getFriends();
  }

  getFriends()
  {
    this.HttpClient.get<any>('https://localhost:44351/api/Student/').subscribe(
      response => {
        console.log(response);
        this.friend = response;
      }
    );
  }
  
}
// open(content){
//   this.modalService.open(content, {ariaLabelledBy: 'modal-basic-tittle'}).result.then(result)) =>{
//     this.closeResult = 'Close with: ${result}';

//   }, (reason) => {
//     this.closeResult = 'Dismissed ${this.getDismissReason{reason}}';
//   }
// }

// private getDismissReason(reason:any) : string {
//   if(reason)
// }


