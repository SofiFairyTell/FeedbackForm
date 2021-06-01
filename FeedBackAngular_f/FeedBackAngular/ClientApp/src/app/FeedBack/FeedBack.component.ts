import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-home',
  templateUrl: './FeedBack.component.html',
  styleUrls: ['./FeedBack.component.css']
})


export class FeedBackComponent {
  //Для проверки введенных данных
  userData = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.pattern("^[a-z0-9._%+-]+\@+[a-z0-9.-]+\.[a-z]{2,4}$")]),
    name: new FormControl('', [
      Validators.required,
      Validators.pattern("^[А-яа-яA-za-z ]{3,}$")]),
    phone: new FormControl('', [
      Validators.required,
      Validators.pattern("^[0-9]{10}$")]),
    subject: new FormControl('', [
      Validators.required]),
    message: new FormControl('', [
      Validators.required]),
    recaptcha: new FormControl('', [
      Validators.required])
  });

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
    this.sharedKey = "6Ld_KtcUAAAAAOQgrVYPNFTUl0uYyyYI8HJeXk13";
    this.captchaURL = "https://www.google.com/recaptcha/api/siteverify";
  }

  posted: boolean = false;
  clicked: boolean = false;
  url: string;
  retained: object;
  sharedKey: string;
  captchaURL: string;

   isButtonDisabled(): boolean {
    return !this.userData.valid;
  }

  public press(): void {
    this.clicked = true;
    const body = {
      id: 0,
      name: this.userData.get('name').value,
      email: this.userData.get('email').value,
      phone: this.userData.get('phone').value,
      subject: this.userData.get('subject').value,
      message: this.userData.get('message').value
    }

    this.http.post(this.url + 'userdatas', body)
      .subscribe((data) => {
        this.retained = data;
        this.posted = true;
        return data;
      })
  }

}
