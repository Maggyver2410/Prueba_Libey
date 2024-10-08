import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { FormControl, FormGroup } from '@angular/forms';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { RegionService } from '../../../core/service/region/region.service';
import { region } from 'src/app/entities/region';
import { switchMap, tap } from 'rxjs';
import { ProvinceService } from '../../../core/service/province/province.service';
import { province } from 'src/app/entities/province';
import { UbigeoService } from '../../../core/service/ubigeo/ubigeo.service';
import { ubigeo } from 'src/app/entities/ubigeo';
import { ActivatedRoute, Router } from '@angular/router';
import { DocumentUser } from 'src/app/entities/documentUser';
@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {
  ListaRegion: region[] = [];
  ListaProvince: province[] = [];
  ListaUbigeo: ubigeo[] = [];
  Listdocument: DocumentUser[] = [];


  public libeyUserForm = new FormGroup({
    documentNumber: new FormControl(''),
    documentTypeId: new FormControl(null),
    name: new FormControl(''),
    fathersLastName: new FormControl(''),
    mothersLastName: new FormControl(''),
    address: new FormControl(''),
    regionCode: new FormControl(null),
    provinceCode: new FormControl(null),
    ubigeoCode: new FormControl(null),
    phone: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });




  constructor(
    private libeyUserService: LibeyUserService,
    private regionService: RegionService,
    private provinceService: ProvinceService,
    private ubigeoService: UbigeoService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
  ) { }


  get currentLibayUser(): LibeyUser {
    const hero = this.libeyUserForm.value as LibeyUser;
    return hero;
  }

  ngOnInit(): void {
    this.getDocument();
    this.getRegions();
    this.onRegionChanged();
    this.onProvinceChanged();

    if (!this.router.url.includes('edit')) return;

    this.activatedRoute.params
      .pipe(
        switchMap(({ id }) => this.libeyUserService.getFindById(id)),
      ).subscribe(user => {

        if (!user) {
          return this.router.navigateByUrl('/');
        }

        this.libeyUserForm.reset(user);
        return;
      });
  }

  Submit() {

    if (this.libeyUserForm.invalid) return;

    if (this.router.url.includes('edit')) {
      this.libeyUserService.updateUser(this.currentLibayUser)
        .subscribe(user => {
          return this.router.navigateByUrl('user/userlist');
        });

      return;
    }
    this.libeyUserService.addUser(this.currentLibayUser)
      .subscribe(user => {
        return this.router.navigateByUrl('user/userlist');
      });



  }


  getRegions() {
    this.regionService.GetAll().subscribe({
      next: (regions) => {
        this.ListaRegion = regions;
      },
      //  error: (err) => (this.errorMessage = err),
    });
  }

  onRegionChanged(): void {
    this.libeyUserForm.get('regionCode')?.valueChanges.pipe(
      tap((_) => {
        this.libeyUserForm.get('provinceCode')?.reset(null);
        this.libeyUserForm.get('ubigeoCode')?.reset(null);
      }),
      switchMap(provinces => this.provinceService.GetProvince(provinces))
    ).subscribe(province => {
      this.ListaProvince = province;
    })

  }
  onProvinceChanged(): void {
    this.libeyUserForm.get('provinceCode')?.valueChanges.pipe(
      tap((_) => {
        this.libeyUserForm.get('ubigeoCode')?.reset(null);
      }),
      switchMap(ubigeos => this.ubigeoService.GetUbigeo(ubigeos))
    ).subscribe(ubigeo => {
      this.ListaUbigeo = ubigeo;
    })
  }
  getDocument() {
    this.libeyUserService.GetDocument()
      .subscribe(document => {
        this.Listdocument = document;
      });
  }
}

