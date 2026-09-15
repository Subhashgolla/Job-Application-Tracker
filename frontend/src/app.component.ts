import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

interface JobApplication {
  id?: number;
  company: string;
  jobTitle: string;
  location: string;
  status: string;
  jobDescription: string;
  notes: string;
  appliedDate: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  private api = 'http://localhost:8080/api/applications';
  applications: JobApplication[] = [];
  form: JobApplication = this.emptyForm();

  constructor(private http: HttpClient) {}

  ngOnInit() { this.load(); }

  emptyForm(): JobApplication {
    return {
      company: '', jobTitle: '', location: '', status: 'Applied',
      jobDescription: '', notes: '', appliedDate: new Date().toISOString()
    };
  }

  load() {
    this.http.get<JobApplication[]>(this.api).subscribe(data => this.applications = data);
  }

  add() {
    if (!this.form.company || !this.form.jobTitle) return;
    this.http.post(this.api, this.form).subscribe(() => {
      this.form = this.emptyForm();
      this.load();
    });
  }

  remove(id?: number) {
    if (!id) return;
    this.http.delete(`${this.api}/${id}`).subscribe(() => this.load());
  }

  count(status: string) {
    return this.applications.filter(x => x.status === status).length;
  }
}
