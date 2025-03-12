import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Candidates } from 'src/app/models/candidates';
import { CandidatesService } from 'src/app/services/candidates.service';

@Component({
  selector: 'get-candidates-by-name',
  templateUrl: './get-candidates-by-name.component.html',
  styleUrls: ['./get-candidates-by-name.component.css']
})
export class GetCandidatesByNameComponent {
  CandidateName:string='';
  candidates:Candidates[]=[];//| null = null;
  constructor(private service : CandidatesService,private activatedRoute : ActivatedRoute ){
   
  }
  ngOnInit():void{}
  findCanName(): void{
    
      this.service.getByName(this.CandidateName).subscribe( data=>{
        this.candidates = data;
        console.log(data);
      });
    
  }
}
