import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { authent2Guard } from './authent2.guard';

describe('authent2Guard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => authent2Guard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
